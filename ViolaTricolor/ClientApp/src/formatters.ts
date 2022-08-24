export const formatDateTime = (dateTime: Date | undefined): string => {
    if (dateTime === undefined) {
        return '';
    }

    function addZero(nm: number) {
        return nm < 10 ? `0${nm}` : nm;
    }

    let day = addZero(dateTime.getDate());
    let month = addZero(dateTime.getMonth() + 1);
    let year = dateTime.getFullYear();
    let hours = addZero(dateTime.getHours());
    let minuts = addZero(dateTime.getMinutes());
    let seconds = addZero(dateTime.getSeconds());

    return `${day}.${month}.${year} ${hours}:${minuts}:${seconds}`;
}
