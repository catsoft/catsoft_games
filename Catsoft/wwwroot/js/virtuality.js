const bookingSetPersonCountUrl = "Booking/SetPersonCount"
const bookingSetDateUrl = "Booking/SetDate"
const bookingSelectAppointTimeUrl = "Booking/SelectAppointTime"

const bookingPrePriceUrl = "Booking/GetPrePrice"

function getDefaultPostOptions(data) {
    console.log(data)
    return {
        method: 'Post',
        headers: {
            // 'Content-Type': 'application/json'
        },
        body: data
    }
}

function getDefaultGetOptions(data) {
    console.log(data)
    return {
        method: 'GET',
        headers: {
            // 'Content-Type': 'application/json'
        },
        body: data
    }
}

function refreshPage() {
    location.reload ? location.reload() : location = location;
}

function executeAndThen(startRequest, nextFunction) {
    startRequest
        .then(response => response.text())
        .then(data => {
            console.log(data)
            nextFunction()
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        })
}

function executeAndUpdate(request, blockId) {
    console.info(blockId);
    request
        .then(response => response.text())
        .then(data => {
            console.log(data)
            document.getElementById(blockId).innerHTML = data
        }
    ).catch(error => {
        console.error('There was a problem with the fetch operation:', error);
        document.getElementById(blockId).innerHTML = 'Failed to load data';
    })
}

function prePricePersonCountSelectionOnChange(e, blockId) {
    console.log(e)
    const formData = new FormData();
    formData.append("personCount", e.options[e.selectedIndex].value)
    const request = fetch(bookingSetPersonCountUrl, getDefaultPostOptions(formData));
    executeAndThen(request, function () {
        updatePrePrice(blockId)
    })
}

function prePriceDateSelectionOnChange(value, blockId) {
    console.log(value)
    const formData = new FormData();
    formData.append("date", value.value)
    const request = fetch(bookingSetDateUrl, getDefaultPostOptions(formData));
    executeAndThen(request, function () {
        updatePrePrice(blockId)
    })
}

function updatePrePrice(blockId) {
    executeAndUpdate(fetch(bookingPrePriceUrl, getDefaultGetOptions()), blockId)
}

function bookingTimeSelectionOnClick(item) {
    var uuid = $(this).attr('datauuid');
    var data = {
        uuid: uuid
    };
    $.post(bookingSelectAppointTimeUrl, data, function () {
        location.reload();
    });
}

function bookingDateSelectionOnChange(selected) {
    var data = {
        date: selected.value
    };
    $.post(bookingSetDateUrl, data, function () {
        location.reload();
    });
}