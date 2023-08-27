import { Button, Divider } from "@fluentui/react-components";
import { ISettings } from "../../models";
import styles from "./Board.module.scss";
import { Text } from "react-native";

export const Board = (props: {
    squares: number[][],
    settings: ISettings;
}) => {
    const {
        squares,
        settings,
    } = props;

    // State

    // Functions

    // Effects

    return (
        <div className={styles.container}>
            {squares.map((row, rowIndex) => (
                <div className={styles.row}>
                    {row.map((item, itemIndex) => (
                        <div className={styles.item}>
                            <Button
                                className={styles.button}
                                shape="square"
                            >
                                <div className={styles.text}>
                                    {settings.characters[item - 1]}
                                </div>
                            </Button>
                        </div>
                    ))}
                </div>
            ))}
        </div>
    );
}