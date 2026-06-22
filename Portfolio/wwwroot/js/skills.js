// View Skills
const viewButton = document.querySelectorAll(".ViewBtn");

const viewName = document.getElementById("ViewName");
const viewImage = document.getElementById("ViewImage");

viewButton.forEach(button => {

    button.addEventListener("click", function () {

        const name = this.dataset.name;
        const image = this.dataset.image;

        viewName.innerText = "Name : " + name;
        viewImage.src = image;

    });

});


// Delete Skills
const deleteButton = document.querySelectorAll(".deleteButton");
const deleteFormSkill = document.getElementById("formDelete");
const deleteMessageSkill = document.getElementById("deleteMessage");

deleteButton.forEach(button => {

    button.addEventListener("click", function (e) {

        e.preventDefault();

        const name = this.dataset.name;
        const id = this.dataset.id;
        deleteMessageSkill.innerText = `Are you sure you want to delete ${name} ?`
        deleteFormSkill.action = `/admin/skills/delete/${id}`;

    })

})