let labName = document.getElementById("lab-name").getAttribute("value");
document.getElementById("lab-name").textContent = labName;
let labDes = document.getElementById("lab-description").getAttribute("value");
document.getElementById("lab-description").textContent = labDes;

let isEdit = false


function editLab() {

    if (!isEdit) {
        document.getElementById("edit-lab-btn").innerHTML = "Save"
        document.getElementById("lab-name").contentEditable = "true"
        document.getElementById("lab-description").contentEditable = "true"
        isEdit = true
    } else {
        var labName = document.getElementById("lab-name");
        var labDes = document.getElementById("lab-description");
        labName.setAttribute("value", document.getElementById("lab-name").innerHTML)
        labDes.setAttribute("value", document.getElementById("lab-description").innerHTML)

        document.getElementById("edit-lab-btn").innerHTML = "Edit"
        document.getElementById("lab-name").contentEditable = "false"
        document.getElementById("lab-description").contentEditable = "false"

        console.log(document.getElementById("lab-name").getAttribute("value"))
        console.log(document.getElementById("lab-description").getAttribute("value"))
        isEdit = false
    }

}


function createItem() {

    const element = document.getElementById("card-list");

    const items = [
        ["อุปกรณ์ 1", true],
        ["อุปกรณ์ 2", true],
        ["อุปกรณ์ 3", true],
        ["อุปกรณ์ 4", false],
        ["อุปกรณ์ 5", false],
        ["อุปกรณ์ 6", true],
        ["อุปกรณ์ 7", false],
        ["อุปกรณ์ 8", true],
    ];

    items.forEach((item) => {
        if (item[1] !== false) {
            const child = document.createElement('div');
            child.setAttribute("class", "item-card");

            const name = document.createElement('div');
            name.setAttribute("class", "item-name");
            name.innerHTML = item[0]

            const btn = document.createElement('button');
            btn.setAttribute("class", "book-btn");
            btn.innerHTML = "book"

            child.appendChild(name);
            child.appendChild(btn);

            element.appendChild(child);
        }
    })


}

createItem();
console.log(':)');


