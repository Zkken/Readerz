interface IApiUrl {
    CardSet: {
        GetAll: string,
        Update: string,
        Delete: string,
        ByCreatorId: string,
        Create: string
    },
    Card: {
        ByCardSetId: string,
        Create: string,
        Delete: string,
        Update: string,
        CreateRange: string
    },
    CardCreator: {
        GetId: string
    },
    Text: {
        Translate: string
    }
}

export const ApiUrl: IApiUrl = {
    CardSet: {
        Create: "api/cardSet/create",
        GetAll: "api/cardSet/all",
        Update: "api/cardSet/update",
        Delete: "api/cardSet/delete",
        ByCreatorId: "api/cardSet/ByCardCreator"
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
        Translate: "api/text/translateWord"
    }
}

