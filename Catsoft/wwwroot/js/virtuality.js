const bookingSetPersonCountUrl = "/Booking/SetPersonCount"
const bookingSetDateUrl = "/Booking/SetDate"
const bookingSelectAppointTimeUrl = "/Booking/SelectAppointTime"

const bookingPrePriceUrl = "/Booking/GetPrePrice"
const bookingSelectedTimesUrl = "/Booking/GetSelectedTimes"

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
// end of common


// region preprice
function prePricePersonCountSelectionOnChange(e, blockId) {
    const formData = new FormData();
    formData.append("personCount", e.options[e.selectedIndex].value)
    const request = fetch(bookingSetPersonCountUrl, getDefaultPostOptions(formData));
    executeAndThen(request, function () {
        updatePrePrice(blockId)
    })
}

function prePriceDateSelectionOnChange(value, blockId) {
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
// region end preprice


//region time selection
function timeSelectionPersonCountOnChange(e, blockId) {
    const formData = new FormData();
    formData.append("personCount", e.options[e.selectedIndex].value)
    const request = fetch(bookingSetPersonCountUrl, getDefaultPostOptions(formData));
    executeAndThen(request, function () {
        updateSelectedTimes(blockId)
    })
}

function timeSelectionSelectionDateOnChange(value, blockId) {
    const formData = new FormData();
    formData.append("date", value.value)
    const request = fetch(bookingSetDateUrl, getDefaultPostOptions(formData));
    executeAndThen(request, function () {
        updateSelectedTimes(blockId)
    })
}

function updateSelectedTimes(blockId) {
    executeAndUpdate(fetch(bookingSelectedTimesUrl, getDefaultGetOptions()), blockId)
}

function bookingTimeSelectionOnClick(item, blockId) {
    const uuid = $(item).attr('datauuid');

    var lightClass = "bg-primary"
    var darkClass = "bg-dark"
    if (item.classList.contains(darkClass)) {
        item.classList.remove(darkClass);
        item.classList.add(lightClass);
    } else {
        item.classList.remove(lightClass);
        item.classList.add(darkClass);
    }
    
    const formData = new FormData();
    formData.append("uuid", uuid)
    const request = fetch(bookingSelectAppointTimeUrl, getDefaultPostOptions(formData));
    executeAndThen(request, function () {
        updateSelectedTimes(blockId)
    })
}
//region end time selection