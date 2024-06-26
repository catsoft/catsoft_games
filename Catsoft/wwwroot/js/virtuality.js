﻿const bookingSetPersonCountUrl = "/Booking/SetPersonCount"
const bookingSetDateUrl = "/Booking/SetDate"
const bookingSelectAppointTimeUrl = "/Booking/SelectAppointTime"

const bookingPrePriceUrl = "/Booking/GetPrePrice"
const bookingCurrentPriceUrl = "/Booking/GetCurrentPrice"
const bookingSelectedTimesUrl = "/Booking/GetSelectedTimes"

const setLanguageUrl = "/Home/SetLanguage"


const currentPriceId = "currentPriceBlockId"


function clickOnId(id) {
    const item = document.getElementById(id);
    item.click()
}

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

function replaceElementById(id, newElementId) {
    // Find the element to be replaced
    const oldElement = document.getElementById(id);
    const newElement = document.getElementById(newElementId).parentElement;

    oldElement.parentNode.replaceChild(newElement, oldElement);
}

function putModel(modelHtml) {
    // Find the element to be replaced
    const oldElement = document.getElementById("modalsHiddenDiv");

    oldElement.innerHTML += modelHtml;
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



// region start language
function setLanguage(e) {
    const formData = new FormData();
    const value = e.value;
    formData.append("language", value)
    const request = fetch(setLanguageUrl, getDefaultPostOptions(formData));
    executeAndThen(request, function () {
        refreshPage()
    })
}
//region end language




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


// region current price
function updateCurrentPrice(blockId) {
    executeAndUpdate(fetch(bookingCurrentPriceUrl, getDefaultGetOptions()), blockId)
}
// regiend end current price


//region time selection
function timeSelectionPersonCountOnChange(e, blockId) {
    const formData = new FormData();
    formData.append("personCount", e.options[e.selectedIndex].value)
    const request = fetch(bookingSetPersonCountUrl, getDefaultPostOptions(formData));
    executeAndThen(request, function () {
        updateSelectedTimes(blockId)
        updateCurrentPrice(currentPriceId)
    })
}

function timeSelectionSelectionDateOnChange(value, blockId) {
    const formData = new FormData();
    formData.append("date", value.value)
    const request = fetch(bookingSetDateUrl, getDefaultPostOptions(formData));
    executeAndThen(request, function () {
        updateSelectedTimes(blockId)
        updateCurrentPrice(currentPriceId)
    })
}

function updateSelectedTimes(blockId) {
    executeAndUpdate(fetch(bookingSelectedTimesUrl, getDefaultGetOptions()), blockId)
}

function bookingTimeSelectionOnClick(item, blockId) {
    const uuid = $(item).attr('datauuid');
    document.querySelectorAll('.appoint-time-container').forEach(function (item) {
        appointTimeToggleBack(item, uuid)
    });

    const formData = new FormData();
    formData.append("uuid", uuid)
    const request = fetch(bookingSelectAppointTimeUrl, getDefaultPostOptions(formData));
    executeAndThen(request, function () {
        updateSelectedTimes(blockId)
        updateCurrentPrice(currentPriceId)
    })
}

function appointTimeToggleBack(item, uuid) {
    const uuidItem = $(item).attr('datauuid')
    if (uuidItem !== uuid) return
    
    var lightClass = "bg-primary"
    var darkClass = "bg-dark"
    if (item.classList.contains(darkClass)) {
        item.classList.remove(darkClass);
        item.classList.add(lightClass);
    } else {
        item.classList.remove(lightClass);
        item.classList.add(darkClass);
    }
}
//region end time selection


// region start person details
function toggleVisibility(checkbox, elementId) {
    // Получаем элемент по его ID
    var element = document.getElementById(elementId);

    // Проверяем, существует ли элемент
    if (!element) {
        console.error("Element with id '" + elementId + "' not found.");
        return;
    }

    // Устанавливаем свойство display в зависимости от состояния чекбокса
    element.style.display = checkbox.checked ? 'block' : 'none';
}
// region end person details