import { Divider, Dropdown, Field, Label, SpinButton, Option } from "@fluentui/react-components";
import { UseGameSettingForm } from "./UseGameSettingForm";
import styles from "./GameSettingForm.module.scss";
import { useEffect, useState } from "react";

export const GameSettingForm = (props: {
    
}) => {
    const {
        
    } = props;

    const {
        playerCount,
        onPlayerCountChange,
        lengthX,
        onLengthXChange,
        lengthY,
        onLengthYChange,
    } = UseGameSettingForm();

    const [playerNames, setPlayerNames] = useState(Array(playerCount).fill(''));

    const handlePlayerNameChange = (index: number, newName: string) => {
        const newPlayerNames = [...playerNames];
        newPlayerNames[index] = newName;
        setPlayerNames(newPlayerNames);
    };

    // Update playerNames array whenever playerCount changes
    useEffect(() => {
        setPlayerNames(Array(playerCount).fill(''));
    }, [playerCount]);

    const options = [
        "Cat",
        "Caterpillar",
        "Corgi",
        "Chupacabra",
        "Dog",
        "Ferret",
        "Fish",
        "Fox",
        "Hamster",
        "Snake",
    ];

    const disabledOptions = [
        "Ferret",
    ];

    return (
        <>
            <Divider appearance="strong">
                <Label weight="semibold">
                    TicTacToe Settings
                </Label>
            </Divider>
            <div
                className={styles.settingsList}
            >
                <Field
                    label="Ammount of players"
                    hint="Minumum 2 players, maximum 4 players."
                >
                    <SpinButton
                        style={{ maxWidth: "100px" }}
                        value={playerCount}
                        onChange={(_, data) => onPlayerCountChange(data.value)}
                        min={2}
                        max={4}
                    />
                </Field>
                <div
                    className={styles.playerSelectors}
                >
                    {Array.from({ length: playerCount }, (_, i) => (
                        <Field
                            label={"Player " + (i + 1)}
                            style={{ maxWidth: "400px" }}
                        >
                            <Dropdown>
                                {options.map((option) => (
                                    <Option key={option} disabled={disabledOptions.includes(option)}>
                                        {option}
                                    </Option>
                                ))}
                            </Dropdown>
                        </Field>
                    ))}
                </div>
                <Field
                    label="With of the board"
                >
                    <SpinButton
                        style={{ maxWidth: "100px" }}
                        value={lengthX}
                        onChange={(_, data) => onLengthXChange(data.value)}
                        min={1}
                    />
                </Field>
                <Field
                    label="Height of the board"
                >
                    <SpinButton
                        style={{ maxWidth: "100px" }}
                        value={lengthY}
                        onChange={(_, data) => onLengthYChange(data.value)}
                        min={1}
                    />
                </Field>
            </div>
        </>
    )
}