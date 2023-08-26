import { Board, Sidebar } from "../../components"
import { UseGame } from "./UseGame";
import styles from "./Game.module.scss";

export const Game = () => {
    const {
        squares,
        restart
    } = UseGame();

    return (
        <div className={styles.container} >
            <div className={styles.board}>
                <Board
                    squares={squares}
                />
            </div>
            <div className={styles.sidebar}>
                <Sidebar

                />
            </div>
        </div>
    )
}