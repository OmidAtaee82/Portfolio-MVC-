const deleteButtons = document.querySelectorAll(".delete-btn");
const deleteForm = document.getElementById("deleteForm");
const deleteMessage = document.getElementById("deleteMessage");

deleteButtons.forEach(button => {

    button.addEventListener("click", function (e) {

        e.preventDefault();
        const id = this.dataset.id;
        const name = this.dataset.name;
        deleteMessage.innerText = `Are you sure you want to delete ${name}?`
        deleteForm.action = `/admin/posts/delete/${id}`
    })

})