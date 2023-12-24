import { Board, Sidebar } from "../../components"
import { UseGame } from "./UseGame";
import styles from "./Game.module.scss";
import { ISettings } from "../../models";

export const Game = (props: {
    settings: ISettings;
}) => {
    const {
        settings,
    } = props;

    const {
        squares,
        currentPlayerId,
        makeMove,
        restart,
    } = UseGame();

    return (
        <div className={styles.container}>
            <div className={styles.board}>
                <Board
                    squares={squares}
                    settings={settings}
                    currentPlayerId={currentPlayerId}
                    makeMove={makeMove}
                />
            </div>
            <div className={styles.sidebar}>
                <Sidebar

                />
            </div>
        </div>
    )
}