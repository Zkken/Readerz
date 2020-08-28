export const ApiUrl = {
    CardSet: {
        Create: "api/cardSet/create",
        GetAll: "api/cardSet/all",
        Update: "api/cardSet/update",
        Delete: "api/cardSet/delete",
        Get: "api/cardSet/get"
    },
    Card: {
        ByCardSetId: "api/card/GetBySet",
        Create: "api/card/create",
        CreateRange: "api/card/createRange",
        Update: "api/card/update",
        Delete: "api/card/delete"
    },
    CardCreator: {
        GetId: "api/cardCreator/current"
    },
    Text: {
        Translate: "api/text/translateWord",
        SupportedLanguages: "api/text/getSupportedLanguages",
        Process: "api/text/process"
    }
}

