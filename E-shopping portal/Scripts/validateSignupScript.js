
const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
const characterRegex = /^[A-Za-z]+$/;
function setError(element, message) {
    element.classList.add("small");
    element.nextElementSibling.innerText = message;
}

function setSuccess(element) {
    element.classList.remove("small");
    element.nextElementSibling.innerText = "";
}

function validateFirstName() {
    let firstName = document.getElementById("firstName");
    let value = firstName.value.trim();
    if (value === "") {
        setError(firstName, "Please enter your first name.");
    }
    else if (!characterRegex.test(value))
    {
        setError(firstName, "Name cannot be a number");
    }
    else {
        setSuccess(firstName);
    }
}

function validateLastName() {
    let lastName = document.getElementById("lastName");
    let value = lastName.value.trim();
    if (value === "") {
        setError(lastName, "Please enter your last name.");
    }
    else if (!characterRegex.test(value)) {
        setError(lastName, "Name cannot be a number");
    }
    else {
        setSuccess(lastName);
    }
}

function validatePhoneNumber() {
    let phoneNumber = document.getElementById("phoneNumber");
    let value = phoneNumber.value.trim();
    if (value === "") {
        setError(phoneNumber, "Please enter your phone number.");
    } else {
        setSuccess(phoneNumber);
    }
}

function validateEmailAddress() {
    let email = document.getElementById("emailAddress");
    let value = email.value.trim();
    if (value === "" || !emailRegex.test(value)) {
        setError(emailAddress, "Please enter a valid email address.");
    }
    else
        {
            setSuccess(emailAddress);
        }
    }

function validateAddress() {
    let address = document.getElementById("address");
    let value = address.value.trim();
    if (value === "") {
        setError(address, "Please enter your address.");
    } else {
        setSuccess(address);
    }
}

function validateState() {
    let state = document.getElementById("state");
    let value = state.value.trim();
    if (value === "") {
        setError(state, "Please select a state.");
    } else {
        setSuccess(state);
    }
}

function validateCity() {
    let city = document.getElementById("city");
    let value = city.value.trim();
    if (value === "") {
        setError(city, "Please enter your city.");
    } else {
        setSuccess(city);
    }
}

function validateUsername() {
    let username = document.getElementById("username");
    let value = username.value.trim();
    if (value === "") {
        setError(username, "Please enter a username.");
    } else {
        setSuccess(username);
    }
}

function validatePassword() {
    let password = document.getElementById("password");
    let value = password.value.trim();
    if (value === "" ) {
        setError(password, "Please enter a password.");
    }
    else if (value.length() < 8) {
        setError(password, "Password must be minimum 8 character");
    }
    else {
        setSuccess(password);
    }
}

function validateConfirmPassword() {
    let confirmPassword = document.getElementById("confirmPassword");
    let password = document.getElementById("password");
    let confirmValue = confirmPassword.value.trim();
    let passwordValue = password.value.trim();
    if (confirmValue === "") {
        setError(confirmPassword, "Please confirm your password.");
    } else if (confirmValue !== passwordValue) {
        setError(confirmPassword, "Passwords do not match.");
    } else {
        setSuccess(confirmPassword);
    }
}


