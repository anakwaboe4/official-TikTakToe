import { Divider, Dropdown, Field, Label, SpinButton, Option, Select } from "@fluentui/react-components";
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

    const [playerNames, setPlayerNames] = useState<string[]>(Array(playerCount).fill(avalibleSettings?.engines ? avalibleSettings?.engines?.[0] : ""));
    
    const handleSelectChange = (index: number, event: any) => {
        const newPlayerNames = [...playerNames];
        newPlayerNames[index] = event.target.value;
        setPlayerNames(newPlayerNames);
    };

    useEffect(() => {
        if(avalibleSettings?.engines && avalibleSettings?.engines.length > 0) {
            setPlayerNames(Array(playerCount).fill(avalibleSettings?.engines[0]));
        }
    }, [avalibleSettings]);

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
                            <Select
                                key={i}
                                value={playerNames[i]}
                                defaultValue={avalibleSettings?.engines ? avalibleSettings?.engines?.[0] : undefined}
                                onChange={(event) => handleSelectChange(i, event)}
                                disabled={avalibleSettings?.engines?.length === 0}
                            >
                                {avalibleSettings?.engines?.map(option => (
                                    <option
                                        key={option + i}
                                        value={option}
                                        disabled={avalibleSettings?.disabledEngines?.includes(option)}
                                    >
                                        {option}
                                    </option>
                                ))}
                            </Select>
                        </Field>  
                    ))}
                </div>
                <Field
                    label="With of the board"
                    hint="Minumum 2 squares, maximum 6 squares."
                >
                    <SpinButton
                        style={{ maxWidth: "100px" }}
                        value={lengthX}
                        onChange={(_, data) => onLengthXChange(data.value)}
                        min={2}
                        max={6}
                    />
                </Field>
                <Field
                    label="Height of the board"
                    hint="Minumum 2 squares, maximum 6 squares."
                >
                    <SpinButton
                        style={{ maxWidth: "100px" }}
                        value={lengthY}
                        onChange={(_, data) => onLengthYChange(data.value)}
                        min={2}
                        max={6}
                    />
                </Field>
            </div>
        </>
    )
}