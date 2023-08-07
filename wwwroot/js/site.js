$(document).ready(function () {
    $(".form-control").on("blur", function () {
        var inputValue = $(this).val();
        var errorMessage = $(this).next(".error-message");
        var label = $(this).prev("label");

        // Validate the input based on its attributes
        if (this.checkValidity()) {
            $(this).removeClass("error").addClass("success");
            errorMessage.css("visibility", "hidden"); // Hide the error message
        } else {
            $(this).addClass("error").removeClass("success");
            errorMessage.css("visibility", "visible");
            label.addClass("text-danger");
        }
    });

    $("#clearButton").on("click", function () {
        $("#taskForm")[0].reset();
    });
});

// Reset the form fields
$(document).ready(function () {
    $("#clearButton").on("click", function () {
        $("#taskForm")[0].reset(); 
    });
});