function displayAllValidationMessagesForGrid(args) {
    var errors = args.errors;
    if (errors) {
        for (var err in errors) {
            var errorMessageDisplayedToUser = "Errors:"
            var errorMessages = errors[err].errors;
            for (var i = 0, len = errorMessages.length; i < len; i++) {
                errorMessageDisplayedToUser += "\n" + errorMessages[i]
            }

            alert(errorMessageDisplayedToUser);
            this.cancelChanges();
        }
    }
}