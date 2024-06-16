import { IGameResponse, IMoveResponse, ISettingsResponse } from "../../models";

export interface IWebApiService {
    // Game
    initializeGame(participantsIds: number[], lengthX: number, lengthY: number, controller?: AbortController): Promise<IGameResponse>;
    makeMovePlayer(playerId: number, square: number): Promise<IMoveResponse>;
    getAvalibleSettings(): Promise<ISettingsResponse>;
}