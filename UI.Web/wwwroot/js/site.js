// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const commentModal = document.getElementById('commentModal');
commentModal.addEventListener('show.bs.modal', (event) => {
    const button = event.relatedTarget; // Button that triggered the modal
    const postId = button.getAttribute('data-post-id'); // Extract info from data-* attributes
    const input = commentModal.querySelector('#postId') // Find the input field in the modal
    input.value = postId; // Update the modal's content.
});