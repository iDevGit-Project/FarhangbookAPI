// Class definition
var KTDatatablesExample = function () {
	// Hook export buttons
	var exportButtons = () => {
		var buttons = new $.fn.dataTable.Buttons(table, {
			buttons: [
				{
					extend: 'pdfHtml5',
				},
				{
					extend: 'excelHtml5',
				},
			]
		}).container().appendTo($('#kt_datatable_buttons'));

		// Hook dropdown menu click event to datatable export buttons
		const exportButtons = document.querySelectorAll('#kt_datatable_export_menu [data-kt-export]');
		exportButtons.forEach(exportButton => {
			exportButton.addEventListener('click', e => {
				e.preventDefault();

				// Get clicked export value
				const exportValue = e.target.getAttribute('data-kt-export');
				const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

				// Trigger click event on hidden datatable export buttons
				target.click();
			});
		});
	}

	// Public methods
	return {
		init: function () {
			table = document.querySelector('#customerDatatable');

			if (!table) {
				return;
			}
			exportButtons();

		}
	};
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
	KTDatatablesExample.init();
});