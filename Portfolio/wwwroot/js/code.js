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


const viewButton = document.querySelectorAll(".ViewBtn");

const viewName = document.getElementById("ViewName");
const viewImage = document.getElementById("ViewImage");

viewButton.forEach(button => {

    button.addEventListener("click", function () {

        console.log("omid ataei");

        const name = this.dataset.name;
        const image = this.dataset.image;

        viewName.innerText = "Name : " + name;
        viewImage.src = image;

    });

});