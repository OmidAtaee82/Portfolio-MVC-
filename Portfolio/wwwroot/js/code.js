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


// delete modal project

const deleteButtonProject = document.querySelectorAll(".btn-delete-project");
const formDeleteProject = document.getElementById("form-delete-project");
const deleteMessageProject = document.getElementById("text-delete-project");

deleteButtonProject.forEach(button => {

    button.addEventListener("click", function (e) {


        console.log("click ...")

        e.preventDefault();

        const id = this.dataset.id;
        const name = this.dataset.name;
        deleteMessageProject.innerText = `Are you sure you want to delete ${name}?`
        formDeleteProject.action = `/admin/projects/delete/${id}`

    })

})