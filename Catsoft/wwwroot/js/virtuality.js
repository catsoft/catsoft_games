function refreshPage(){
    location.reload ? location.reload() : location = location;
}

function bookingPersonCountSelectionOnChange(selected) {
    var url = "Booking/SetPersonCount"
    var data = {
        personCount: selected.value
    };
    $.post(url, data, function () {
        location.reload();
    });
}

function bookingTimeSelectionOnClick(item) {
    var uuid = $(this).attr('datauuid');
    var url = "Booking/SelectAppointTime"
    var data = {
        uuid: uuid
    };
    $.post(url, data, function () {
        location.reload();
    });
}

function bookingDateSelectionOnChange(selected) {
    var url = "Booking/SetDate"
    var data = {
        date: selected.value
    };
    $.post(url, data, function () {
        location.reload();
    });
}