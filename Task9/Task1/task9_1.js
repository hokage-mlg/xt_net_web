function repeatRemover(str) {
    var separators = ['.', ',', '?', '!', ':', ';', ' ', '\t'];
    var words = [];
    var repeated = [];
    var i = 0;
    var temp = 0;
    var chars = str.split('');
    do {
        i++;
        if (separators.includes(str[i]) || i == str.length) {
            words.push(str.slice(temp, i));
            while (separators.includes(str[i]) && i != str.length) {
                i++;
            }
            temp = i;
        }
    } while (i < str.length);
    words.forEach(word => {
        for (var i = 0; i < word.length - 1; i++) {
            for (var j = i + 1; j < word.length; j++) {
                if (word[i] == word[j] && !repeated.includes(word[i])) {
                    repeated.push(word[i]);
                    j = word.length;
                }
            }
        }
    });
    for (var i = chars.length - 1; i >= 0; i--) {
        if (repeated.includes(chars[i])) {
            chars.splice(i, 1);
        }
    }
    return chars.join('');
}

function remove() {
    document.getElementById("output").value = repeatRemover(document.getElementById("input").value);
}