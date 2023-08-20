import { useState } from "react"
import { useWebApi } from "../../context";

export const UseGame = (

): {
    squares: number[][],
    restart: () => void
} => {
    // Hooks
    const webApi = useWebApi();
    
    // State
    const [squares, setSquares] = useState<number[][]>([[]]);

    // Functions
    const restart = async () => {
        const response = await webApi.initializeGame([0, 0], 3, 3)
        setSquares(response.board);
    }

    return {
        squares,
        restart
    }
}