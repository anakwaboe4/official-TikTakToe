import { Divider, Dropdown, Field, Label, SpinButton, Option } from "@fluentui/react-components";
import { UseGameSettingForm } from "./UseGameSettingForm";
import styles from "./GameSettingForm.module.scss";
import { useEffect, useState } from "react";
import { ISettingsResponse } from "../../models";

export const GameSettingForm = (props: {
    avalibleSettings: ISettingsResponse,
}) => {
    const {
        avalibleSettings,
    } = props;

    const {
        playerCount,
        onPlayerCountChange,
        lengthX,
        onLengthXChange,
        lengthY,
        onLengthYChange,
    } = UseGameSettingForm();

    const [playerNames, setPlayerNames] = useState<string[]>(Array(playerCount).fill(undefined));

    const handlePlayerNameChange = (index: number, newName: string) => {
        if (avalibleSettings.engines && !(avalibleSettings.engines.includes(newName))) {
            const newPlayerNames = [...playerNames];
            newPlayerNames[index] = newName;
            setPlayerNames(newPlayerNames);
        }
    };

    // Update playerNames array whenever playerCount changes
    useEffect(() => {
        setPlayerNames((prevPlayerNames) => {
            const newPlayerNames = [...prevPlayerNames];
            if (newPlayerNames.length < playerCount) {
                for (let i = newPlayerNames.length; i < playerCount; i++) {
                    newPlayerNames.push(avalibleSettings.engines && avalibleSettings.engines.length > 0 ? avalibleSettings.engines[0] : "");
                }
            } else if (newPlayerNames.length > playerCount) {
                newPlayerNames.splice(playerCount);
            }
            return newPlayerNames;
        });
    }, [playerCount]);

    useEffect(() => {
        if(avalibleSettings.engines && avalibleSettings.engines.length > 0) {
            setPlayerNames(Array(playerCount).fill(avalibleSettings.engines[0]));
        }
    }, [avalibleSettings]);

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
        "Default",
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
                            validationState={!playerNames[i] || !(playerNames[i].length > 0) ? "error" : undefined}
                            validationMessage={!playerNames[i] || !(playerNames[i].length > 0) ? "Select an option." : undefined}
                        >
                            <Dropdown
                                value={playerNames[i]}
                                defaultValue={avalibleSettings.engines && avalibleSettings.engines.length > 0 ? avalibleSettings.engines[0] : ""}
                                selectedOptions={avalibleSettings.engines}
                                onOptionSelect={(_, data) => handlePlayerNameChange(i, data.optionValue as string)}
                                disabled={!avalibleSettings.engines || avalibleSettings.engines.length === 0}
                            >
                                {avalibleSettings.engines && avalibleSettings.engines.map((option) => (
                                    <Option
                                        key={option}
                                        disabled={disabledOptions.includes(option)}
                                    >
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