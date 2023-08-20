import { Board } from "../../components"
import { UseGame } from "./UseGame";

export const Game = () => {
    const {
        squares,
        restart
    } = UseGame();

    return (
        <div>
            <Board
                squares={squares}
            />
        </div>
    )
}