import { IGamePostBody, IGameResponse, IMoveResponse, IPlayerMoveRequest } from "../models";
import { WebApiServiceBase } from "./WebApiServiceBase";
import { IWebApiService } from "./interfaces/IWebApiService";

export class WebApiService extends WebApiServiceBase implements IWebApiService {
    // Game
    public async initializeGame(participantsIds: number[], lengthX: number, lengthY: number, controller?: AbortController): Promise<IGameResponse> {
        const body = {
            participantsIds,
            lengthX,
            lengthY
        }

        const response = await this.executePost<IGameResponse, IGamePostBody>("/games", body, controller);

        return response || {} as IGameResponse;
    }
    public async makeMovePlayer(playerId: number, square: number): Promise<IMoveResponse> {
        const body = {
            playerId,
            square,
        }

        const response = await this.executeRequest<IMoveResponse>("/games/move", "PUT", undefined, undefined, undefined, JSON.stringify(body));

        return response || {} as IMoveResponse;
    }
}