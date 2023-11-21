const ValidationPatterns = {
    EMAIL: /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
    PHONE_NUMBER: /^(\+)?([0-9])*$/,
    CARD_NUMBER: /^([0-9]{4}( |\-)){3}[0-4]{4}$/
}

export default ValidationPatterns;