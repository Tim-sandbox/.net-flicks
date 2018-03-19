﻿$(function () {
    //Set up Bootstrap tooltips
    $('[data-toggle="tooltip"]').tooltip();

    //Sort movie cards
    $(document).on('click', '.sort-movies', function () {
        var elementId = this.id;
        var sortData = elementId.split("-");
        var attr = sortData[1];
        var order = sortData[2];

        tinysort('div.movie-column', { attr: 'data-' + attr, order: order });

        $(".sort-movies").each(function (index) {
            if ($(this).attr('id') === elementId) {
                $(this).addClass('active text-white');
            } else {
                $(this).removeClass('active text-white');
            }
        });

        $('#sort-movies-dropdown').text(attr[0].toUpperCase() + attr.slice(1) + ' (' + order[0].toUpperCase() + order.slice(1) + '.)');
    });

    //Toggled open/closed icon on collapsible cards
    $('.collapse-card').on('click', function () {
        $(this)
            .find('[data-fa-i2svg]')
            .toggleClass('fa-chevron-up')
            .toggleClass('fa-chevron-down');
    });

    //Update image modals
    $('.image-modal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);

        var title = button.data('title');
        var imageSource = button.data('img-src');

        var modal = $(this);
        modal.find('.modal-title').text(title);
        modal.find('img').attr('src', imageSource);
    });

    //Add New Cast Member in Edit Crew modal
    $(document).on('click', '.add-cast-member', function () {
        var nextIndex = $('#cast-table tbody tr').length;

        $.ajax({
            url: '../../Movie/AddCastMember',
            data: { index: nextIndex },
            type: 'GET'
        }).done(function (response) {
            $('#cast-table tbody').append(response);

            //Refresh bootstrap-select so that it sets up the JS for new dropdowns
            $('.selectpicker').selectpicker();
        });
    });

    //Add New Crew Member in Edit Crew modal
    $(document).on('click', '.add-crew-member', function () {
        var nextIndex = $('#crew-table tbody tr').length;

        $.ajax({
            url: '../../Movie/AddCrewMember',
            data: { index: nextIndex },
            type: 'GET'
        }).done(function (response) {
            $('#crew-table tbody').append(response);

            //Refresh bootstrap-select so that it sets up the JS for new dropdowns
            $('.selectpicker').selectpicker();
        });
    });

    //Delete Person in Edit Cast and Edit Crew modals
    $('.people-table').on('click', '.delete-person', function () {
        $(this).closest('td').find('input').val('true');
        $(this).closest('tr').hide();
    });
});