$(document).ready(function () {
    // Attach an event handler to the blur event for text boxes with the "alphabets-only" class
    $(".alphabets-only").on("blur", function () {
        var inputValue = $(this).val();
        // Validate the input value to allow only alphabets and white spaces
        if (!/^[A-Za-z\s]+$/.test(inputValue)) {
            $(this).addClass("error").removeClass("success");
            $(this).next(".text-danger").css("visibility", "visible"); // Show the error message
        } else {
            $(this).removeClass("error").addClass("success");
            $(this).next(".text-danger").css("visibility", "hidden"); // Hide the error message
        }
    });

    // Attach an event handler to the blur event for text boxes with the "numbers-only" class
    $(".numbers-only").on("blur", function () {
        var inputValue = $(this).val();
        // Validate the input value to allow only numeric values (including decimals)
        if (!/^\d+(\.\d+)?$/.test(inputValue)) {
            $(this).addClass("error").removeClass("success");
            $(this).next(".text-danger").css("visibility", "visible"); // Show the error message
        } else {
            $(this).removeClass("error").addClass("success");
            $(this).next(".text-danger").css("visibility", "hidden"); // Hide the error message
        }
    });
});

$(document).ready(function () {
    // Add a click event handler for the "Clear" button
    $("#clearButton").on("click", function () {
        // Reset the form fields
        $("#taskForm")[0].reset();
    });
});