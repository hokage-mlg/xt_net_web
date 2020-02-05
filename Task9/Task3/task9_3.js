function moveSelected(initial, destination) {
    var optionsInitial = initial.options;
    var isSelect = false;
    for (var i = 0; i < optionsInitial.length; i++) {
        if (optionsInitial[i].selected) {
            optionsInitial[i].selected = false;
            destination.add(optionsInitial[i]);
            i--;
            isSelect = true;
        }
    }
    if (isSelect == false) {
        alert("Error! Select element.");
    }
}

function moveAll(initial, destination) {
    var optionsInitial = initial.options;
    for (var i = 0; i < optionsInitial.length; i++) {
        optionsInitial[i].selected = false;
        destination.add(optionsInitial[i]);
        i--;
    }
}