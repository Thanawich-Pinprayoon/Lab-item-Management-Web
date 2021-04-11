
function createItem() {

    const element = document.getElementById("card-list");

    const items = [
        ["อุปกรณ์ 1", true],
        ["อุปกรณ์ 2", true],
        ["อุปกรณ์ 3", true],
        ["อุปกรณ์ 4", false],
        ["อุปกรณ์ 5", false],
        ["อุปกรณ์ 6", true],
        ["อุปกรณ์ 7", false]
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
