function validateForm() {
    var rating = document.querySelector('input[name="Rating"]:checked');
    var comment = document.getElementById("comment").value;

    // Check if either rating or comment is filled out
    if (!rating && !comment.trim()) {
        // Display custom alert message
        alert("Feedback can't be empty. Please rate us or leave a comment.");
        return false; // Prevent form submission
    }

    // Form is valid, allow submission
    return true;
}
