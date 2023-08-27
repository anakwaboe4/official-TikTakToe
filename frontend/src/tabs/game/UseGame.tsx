import { useState } from "react"
import { useWebApi } from "../../context";
import { WebApiService } from "../../services/WebApiService";

export const UseGame = (

): {
    squares: number[][],
    currentPlayerId: number,
    makeMove: (playerId: number, square: number) => void,
    restart: () => void,
} => {
    // Hooks
    const webApi = useWebApi();
    
    // State
    const [squares, setSquares] = useState<number[][]>([[0, 1, 0], [2, 0, 0], [0, 0, 0]]);
    const [currentPlayerId, setCurrentPlayerId] = useState<number>(0);

    // Functions
    const makeMove = async (playerId: number, square: number) => {
        console.log({playerId, square});
        const response = await webApi.makeMovePlayer(playerId, square);
        setSquares(response.board);
    }
    const restart = async () => {
        const response = await webApi.initializeGame([0, 0], 3, 3);
        setSquares(response.board);
    }

    return {
        squares,
        currentPlayerId,
        makeMove,
        restart,
    }
}