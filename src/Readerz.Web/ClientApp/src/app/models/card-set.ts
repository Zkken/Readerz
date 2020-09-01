import { Card } from "./card";

export class CardSet {
    constructor(
        public id?: number,
        public name?: string,
        public status?: CardSetStatus,
        public like?: number,
        public dislike?: number,
        public timesPlayed?: number 
        ) {

        }
}

export enum CardSetStatus {
    Private = "Private",
    Public = "Public"
}

export interface CardSets {
    data: CardSet[],
    pageIndex: number,
    pageSize: number,
    totalPages: number,
    hasPreviousPage: boolean,
    hasNextPage: boolean
}

export interface CreateCardSetCommand {
    name: string,
    status: CardSetStatus,
    textId?: number,
}

export interface UpdateCardSetCommand {
    id: number,
    name: string,
    status: CardSetStatus
}

export class CardSetDetail {
    constructor(
        public id?: number,
        public name?: string,
        public status?: CardSetStatus,
        public like?: number,
        public dislike?: number,
        public timesPlayed?: number,
        public cards?: Card[] 
        ) {

        }
}