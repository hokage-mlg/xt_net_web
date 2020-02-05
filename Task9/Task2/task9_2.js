function Calculator(str) {
    var arr = str.match(/(^\-)?\d+(\.\d+)?|[\+,\-,\*,\/,\=]{1}/ig);
    var result = arr[0] * 1;
    if (arr == null) {
        return 0;
    }
    for (let i = 0; i < arr.length; i++) {
        switch (arr[i]) {
            case "+":
                result += arr[i + 1] * 1;
                break;
            case "-":
                result -= arr[i + 1] * 1;
                break;
            case "*":
                result *= arr[i + 1] * 1;
                break;
            case "/":
                result /= arr[i + 1] * 1;
                break;
            default:
                break;
        }
    }
    return result.toFixed(2);
}