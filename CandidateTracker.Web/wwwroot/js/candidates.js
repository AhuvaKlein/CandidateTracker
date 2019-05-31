$(() => {

    $('#toggle-notes').on('click', function () {
        console.log('hello');
        $('.notes').toggle();
    });

    $('#confirm').on('click', function () {

        const id = $('#confirm').data('id');
        $.post('/home/confirmcandidate', { id }, function (ids) {

            document.getElementById('pending-count').textContent = ids.pending;
            document.getElementById('confirmed-count').textContent = ids.confirmed;
            document.getElementById('declined-count').textContent = ids.declined;
            $('#button-row').hide();
        });

    })

    $('#decline').on('click', function () {

        const id = $('#decline').data('id');
        $.post('/home/declinecandidate', { id }, function (ids) {

            document.getElementById('pending-count').textContent = ids.pending;
            document.getElementById('confirmed-count').textContent = ids.confirmed;
            document.getElementById('declined-count').textContent = ids.declined;
            $('#button-row').hide();
        });

    })

})