/**
 * An Tâm Pharmacy - Main JavaScript
 * AJAX Add to Cart & Interactive UI
 */

document.addEventListener('DOMContentLoaded', function () {
    initAjaxAddToCart();
    initCategoryBackdrop();
});

function initAjaxAddToCart() {
    // Lắng nghe sự kiện submit trên bất kỳ form nào gửi đến Cart/AddToCart
    document.addEventListener('submit', function (e) {
        const form = e.target;
        if (!form || !form.action || !form.action.toLowerCase().includes('cart/addtocart')) {
            return;
        }

        // Chặn reload trang
        e.preventDefault();

        const submitBtn = form.querySelector('button[type="submit"]') || form.querySelector('button');
        const originalBtnHtml = submitBtn ? submitBtn.innerHTML : '';

        // Hiển thị trạng thái đang xử lý trên nút
        if (submitBtn) {
            submitBtn.disabled = true;
            submitBtn.innerHTML = '<span class="spinner-border spinner-border-sm me-1" role="status" aria-hidden="true"></span> Đang thêm...';
        }

        const formData = new FormData(form);

        fetch(form.action, {
            method: 'POST',
            body: formData,
            headers: {
                'X-Requested-With': 'XMLHttpRequest'
            }
        })
        .then(response => {
            if (!response.ok) {
                throw new Error('Mạng hoặc máy chủ gặp sự cố');
            }
            return response.json();
        })
        .then(data => {
            if (data.success) {
                // 1. Cập nhật số lượng giỏ hàng trên badge
                updateCartBadge(data.cartCount);

                // 2. Hiển thị thông báo Toast đẹp mắt
                showAddToCartToast(data);

                // 3. Phản hồi thành công trên nút bấm
                if (submitBtn) {
                    submitBtn.classList.add('btn-added-state');
                    submitBtn.innerHTML = '<i class="bi bi-check2-circle me-1"></i> Đã thêm!';

                    setTimeout(() => {
                        submitBtn.classList.remove('btn-added-state');
                        submitBtn.innerHTML = originalBtnHtml;
                        submitBtn.disabled = false;
                    }, 1500);
                }
            } else {
                alert(data.message || 'Không thể thêm sản phẩm vào giỏ hàng.');
                if (submitBtn) {
                    submitBtn.innerHTML = originalBtnHtml;
                    submitBtn.disabled = false;
                }
            }
        })
        .catch(error => {
            console.error('Lỗi khi thêm giỏ hàng:', error);
            // Fallback: nếu xảy ra lỗi mạng đặc biệt, submit thông thường
            form.submit();
        });
    });
}

/**
 * Cập nhật số lượng trên icon giỏ hàng và hiệu ứng rung/nhấp nháy
 */
function updateCartBadge(count) {
    const badge = document.getElementById('cartBadgeCount');
    if (badge) {
        badge.textContent = count;
        badge.classList.remove('badge-pulse');
        // Force reflow
        void badge.offsetWidth;
        badge.classList.add('badge-pulse');
    }
}

let activeToastTimer = null;

/**
 * Hiển thị Toast thông báo thêm vào giỏ thành công (Chỉ hiện 1 cái duy nhất, click xem giỏ)
 */
function showAddToCartToast(data) {
    let container = document.getElementById('toastNotificationContainer');
    if (!container) {
        container = document.createElement('div');
        container.id = 'toastNotificationContainer';
        container.className = 'toast-container position-fixed top-0 end-0 p-3';
        container.style.zIndex = '1095';
        container.style.marginTop = '70px';
        document.body.appendChild(container);
    }

    // ĐẢM BẢO CHỈ HIỂN THỊ DUY NHẤT 1 TOAST THÔNG BÁO TẠI MỌI THỜI ĐIỂM
    if (activeToastTimer) {
        clearTimeout(activeToastTimer);
        activeToastTimer = null;
    }
    container.innerHTML = '';

    const toastId = 'toast_' + Date.now();
    const product = data.product || {};
    const imgHtml = product.imageUrl 
        ? `<img src="${product.imageUrl}" alt="${product.name || 'Thuốc'}" class="medical-toast-img">`
        : `<div class="medical-toast-img d-flex align-items-center justify-content-center bg-light text-teal"><i class="bi bi-capsule fs-4"></i></div>`;

    const toastHtml = `
        <div id="${toastId}" class="medical-toast mb-3 shadow" role="alert" aria-live="assertive" aria-atomic="true" onclick="navigateToCart(event)" title="Bấm vào đây để xem giỏ hàng ngay">
            <div class="medical-toast-header">
                <div class="d-flex align-items-center gap-2">
                    <i class="bi bi-check-circle-fill text-warning"></i>
                    <span>Thêm Vào Giỏ Thành Công</span>
                </div>
                <button type="button" class="btn-close btn-close-white btn-sm" aria-label="Đóng" onclick="dismissCustomToast(event, '${toastId}')"></button>
            </div>
            <div class="medical-toast-body">
                ${imgHtml}
                <div class="flex-grow-1 overflow-hidden">
                    <div class="fw-bold text-dark text-truncate small mb-1">${product.name || 'Sản phẩm y tế'}</div>
                    <div class="d-flex justify-content-between align-items-center">
                        <span class="text-danger fw-bold small">${product.price || ''}</span>
                        <span class="badge bg-light text-muted border">SL: +${product.addedQuantity || 1}</span>
                    </div>
                </div>
            </div>
            <div class="medical-toast-footer px-3 py-2 d-flex justify-content-between align-items-center">
                <span class="small text-teal fw-semibold">
                    <i class="bi bi-bag-check-fill me-1"></i> Bấm để xem giỏ hàng
                </span>
                <button type="button" class="btn btn-sm btn-teal py-1 px-3 text-white fw-bold rounded-pill small shadow-sm" onclick="navigateToCart(event)">
                    Xem Giỏ <i class="bi bi-arrow-right ms-1"></i>
                </button>
            </div>
        </div>
    `;

    container.insertAdjacentHTML('beforeend', toastHtml);

    // Tự động ẩn sau 4.5 giây
    activeToastTimer = setTimeout(() => {
        dismissCustomToast(null, toastId);
    }, 4500);
}

function navigateToCart(e) {
    if (e) {
        e.stopPropagation();
    }
    window.location.href = '/Cart';
}

function dismissCustomToast(e, toastId) {
    if (e) {
        e.stopPropagation();
    }
    const el = document.getElementById(toastId);
    if (el) {
        el.style.transition = 'opacity 0.25s ease, transform 0.25s ease';
        el.style.opacity = '0';
        el.style.transform = 'translateX(40px) scale(0.95)';
        setTimeout(() => {
            if (el.parentNode) {
                el.parentNode.removeChild(el);
            }
        }, 250);
    }
}

/**
 * Xử lý bôi đen phần bên ngoài khi ấn danh mục sản phẩm (Category Backdrop)
 */
function initCategoryBackdrop() {
    const backdrop = document.getElementById('categoryBackdrop');
    if (!backdrop) return;

    const categoryDropdown = document.getElementById('categoryDropdown');
    const pharmacyNav = document.getElementById('pharmacyNav');
    const categorySidebarCollapse = document.getElementById('categorySidebarCollapse');

    function checkAnyOpen() {
        const isDropdownOpen = categoryDropdown && categoryDropdown.getAttribute('aria-expanded') === 'true';
        const isNavOpen = pharmacyNav && pharmacyNav.classList.contains('show');
        const isSidebarOpen = categorySidebarCollapse && categorySidebarCollapse.classList.contains('show');
        return isDropdownOpen || isNavOpen || isSidebarOpen;
    }

    function lockBodyScroll() {
        document.body.classList.add('popup-locked');
        document.documentElement.classList.add('popup-locked');
    }

    function unlockBodyScroll() {
        document.body.classList.remove('popup-locked');
        document.documentElement.classList.remove('popup-locked');
    }

    function showBackdrop() {
        backdrop.classList.add('show');
        lockBodyScroll();
    }

    function hideBackdrop() {
        setTimeout(() => {
            if (!checkAnyOpen()) {
                hideBackdropImmediate();
            }
        }, 80);
    }

    const mainHeader = document.querySelector('.pharmacy-main-header');

    function hideBackdropImmediate() {
        backdrop.classList.remove('show');
        backdrop.classList.remove('backdrop-over-header');
        if (mainHeader) mainHeader.classList.remove('header-nav-open');
        unlockBodyScroll();
    }

    // Ngăn chặn cuộn trang nền khi chạm vào lớp phủ đen (chỉ cuộn được trong popup)
    backdrop.addEventListener('touchmove', function (e) {
        e.preventDefault();
    }, { passive: false });

    // 1. Dropdown "Danh Mục Sản Phẩm" trên Header
    if (categoryDropdown) {
        categoryDropdown.addEventListener('show.bs.dropdown', showBackdrop);
        categoryDropdown.addEventListener('hide.bs.dropdown', hideBackdropImmediate);
    }

    // 2. Menu Navigation Mobile (Hiện dạng POPUP)
    if (pharmacyNav) {
        pharmacyNav.addEventListener('show.bs.collapse', function () {
            if (categorySidebarCollapse && categorySidebarCollapse.classList.contains('show') && typeof bootstrap !== 'undefined') {
                bootstrap.Collapse.getOrCreateInstance(categorySidebarCollapse).hide();
            }
            if (mainHeader) mainHeader.classList.add('header-nav-open');
            backdrop.classList.add('backdrop-over-header');
            showBackdrop();
        });
        pharmacyNav.addEventListener('hide.bs.collapse', function () {
            if (mainHeader) mainHeader.classList.remove('header-nav-open');
            backdrop.classList.remove('backdrop-over-header');
            hideBackdropImmediate();
        });
    }

    // 3. Bộ lọc & Danh mục bên trang Sản phẩm (Mobile)
    if (categorySidebarCollapse) {
        categorySidebarCollapse.addEventListener('show.bs.collapse', function () {
            if (pharmacyNav && pharmacyNav.classList.contains('show') && typeof bootstrap !== 'undefined') {
                bootstrap.Collapse.getOrCreateInstance(pharmacyNav).hide();
            }
            backdrop.classList.add('backdrop-over-header');
            showBackdrop();
        });
        categorySidebarCollapse.addEventListener('hide.bs.collapse', function () {
            backdrop.classList.remove('backdrop-over-header');
            hideBackdropImmediate();
        });
    }

    // Click vào vùng bôi đen để đóng danh mục ngay lập tức
    backdrop.addEventListener('click', function () {
        hideBackdropImmediate();

        if (categoryDropdown && typeof bootstrap !== 'undefined') {
            const ddInstance = bootstrap.Dropdown.getInstance(categoryDropdown);
            if (ddInstance) ddInstance.hide();
        }

        if (pharmacyNav && pharmacyNav.classList.contains('show')) {
            if (typeof bootstrap !== 'undefined') {
                bootstrap.Collapse.getOrCreateInstance(pharmacyNav).hide();
            } else {
                pharmacyNav.classList.remove('show');
            }
        }

        if (categorySidebarCollapse && categorySidebarCollapse.classList.contains('show')) {
            if (typeof bootstrap !== 'undefined') {
                bootstrap.Collapse.getOrCreateInstance(categorySidebarCollapse).hide();
            } else {
                categorySidebarCollapse.classList.remove('show');
            }
        }
    });

    // Khi chọn bất kỳ danh mục nào, tắt vùng bôi đen và mở khóa cuộn trang
    document.querySelectorAll('.dropdown-item, .filter-category-item').forEach(item => {
        item.addEventListener('click', function () {
            hideBackdropImmediate();
        });
    });
}

