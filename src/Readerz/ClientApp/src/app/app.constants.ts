interface apiUrl {
    CardSet: {
        GetAll: string,
        Update: string,
        Delete: string,
        ByCreatorId: string
    },
    Card: {

    },
    CardCreator: {
        GetId: string
    }
}

export const ApiUrl: apiUrl = {
    CardSet: {
        GetAll: "api/cardSet/all",
        Update: "api/cardSet/update",
        Delete: "api/cardSet/delete",
        ByCreatorId: "api/cardSet/ByCardCreator"
    },
    Card: {

    },
    CardCreator: {
        GetId: "api/cardCreator/current"
    }
}

