
function SelectCategory(id) {
    var xhr = new XMLHttpRequest();
    xhr.open("POST", `api/index/getrecipts?id=${id}`);
    xhr.onload = function (e) {
        var element = document.getElementById('recipt');
        element.innerHTML = "";
        var json = JSON.parse(xhr.response);
        for (var i = 0; i < json.length; i++) {
            element.innerHTML += `<option value="${i}">${json[i].recName}</option>`
        }
        document.getElementById('data').innerHTML = xhr.response;
        SelectRecipt(0);
    }
    xhr.send();
}
function SelectRecipt(id) {
    var json = JSON.parse(document.getElementById('data').innerHTML);
    var element = document.getElementById('card');
    var recipt = json[Number.parseInt(id)];
    var ingridients = "";
    for (var i = 0; i < recipt.ingredients.length; i++)
        ingridients += `${recipt.ingredients[i].products.prodName} ${recipt.ingredients[i].quantity} ${recipt.ingredients[i].products.units.unitName}<br>`;
    var comments = "";
    for (var i = 0; i < recipt.reviews.length; i++)
        comments += `${recipt.reviews[i].user.usName} ${recipt.reviews[i].user.usSurname} ${recipt.reviews[i].revMessage} ${recipt.reviews[i].revDate} ${recipt.reviews[i].revRating} <br>`;
    if (json.length > 0) {
        element.innerHTML =
            `<div class="card-header" id="title" name="${recipt.id}">
${recipt.recName}
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div id="description">${recipt.recipt}</div>
            </blockquote>
        </div>
<div class="card-footer text-muted">
    ${ingridients}
  </div>
<div class="card-footer text-muted">
    ${comments}
  </div>`;
        document.getElementById('reciptsId').value = recipt.id;
    }
    else element.innerHTML = '';
}
SelectCategory(-1);