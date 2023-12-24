import { useState } from "react"
import { useWebApi } from "../../context";
import {
    useToastController
} from "@fluentui/react-components";
import { DefaultToast } from "../../components";

export const UseGame = (
    toastControllerId: string,
): {
    squares: number[][],
    currentPlayerId: number,
    makeMove: (playerId: number, square: number) => void,
    restart: () => void,
} => {
    // Hooks
    const webApi = useWebApi();
    const { dispatchToast } = useToastController(toastControllerId);
    
    // State
    const [squares, setSquares] = useState<number[][]>([[0, 1, 0], [2, 0, 0], [0, 0, 0]]);
    const [currentPlayerId, setCurrentPlayerId] = useState<number>(0);

    // Functions
    const makeMove = async (playerId: number, square: number) => {
        try {
            console.log({playerId, square});
            const response = await webApi.makeMovePlayer(playerId, square);
            setSquares(response.board);
        }
        catch (error) {
            dispatchToast(
                <DefaultToast
                    message="Something went wrong while calling the API"
                />,
                {
                    intent: "error",
                }
            );
        }
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