import { Board, Sidebar } from "../../components"
import { UseGame } from "./UseGame";
import styles from "./Game.module.scss";
import { ISettings } from "../../models";

export const Game = (props: {
    settings: ISettings;
    toastControllerId: string;
}) => {
    const {
        settings,
        toastControllerId,
    } = props;

    const {
        squares,
        currentPlayerId,
        makeMove,
        restart,
    } = UseGame(toastControllerId);

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