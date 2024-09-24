window.showModal = (modalId) => {
    var modal = new bootstrap.Modal(document.getElementById(modalId));
    modal.show();
};

window.hideModal = (modalId) => {
    var modal = new bootstrap.Modal(document.getElementById(modalId));
    modal.hide();
};
