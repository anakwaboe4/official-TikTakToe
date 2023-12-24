import { Button } from "@fluentui/react-components";
import { ISettings } from "../../models";
import styles from "./Board.module.scss";

export const Board = (props: {
    squares: number[][],
    settings: ISettings,
    currentPlayerId: number,
    makeMove: (playerId: number, square: number) => void,
}) => {
    const {
        squares,
        settings,
        currentPlayerId,
        makeMove,
    } = props;

    // State

    // Functions
    const onSquareClick = (square: number) => {
        makeMove(currentPlayerId, square);
    }

    // Effects

    return (
        <div className={styles.container}>
            {squares.map((row, rowIndex) => (
                <div className={styles.row}>
                    {row.map((item, itemIndex) => (
                        <div className={styles.item}>
                            <Button
                                className={item !== 0 ? styles.buttonFilled : styles.buttonEmpty}
                                shape="square"
                                appearance={item === 0 ? (undefined) : "outline"}
                                onClick={() => {onSquareClick((rowIndex * settings.lengthX) + itemIndex)}}
                            >
                                {item !== 0 && <div className={styles.text}>
                                    {settings.characters[item - 1]}
                                </div>}
                            </Button>
                        </div>
                    ))}
                </div>
            ))}
        </div>
    );
}