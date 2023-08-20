import { IGameResponse } from "../../models";

export interface IWebApiService {
    // Game
    initializeGame(participantsIds: number[], lengthX: number, lengthY: number, controller?: AbortController): Promise<IGameResponse>;
}