import { Divider, Dropdown, Field, Label, SpinButton, Option, Select, Persona } from "@fluentui/react-components";
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

    const [playerNames, setPlayerNames] = useState<string[]>(Array(2).fill(avalibleSettings?.engines ? avalibleSettings?.engines?.[0] : ""));
    
    const handlePlayerNameChange = (index: number, newName: string) => {
        if (avalibleSettings.engines && (avalibleSettings.engines.includes(newName))) {
            let newPlayerNames = [...playerNames];
            newPlayerNames[index] = newName;
            setPlayerNames(newPlayerNames);
        }
    };

    useEffect(() => {
        if(avalibleSettings?.engines && avalibleSettings?.engines.length > 0) {
            setPlayerNames(Array(playerCount).fill(avalibleSettings?.engines[0]));
        }
    }, [avalibleSettings]);

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
                        disabled={true}
                    />
                </Field>
                <div
                    className={styles.playerSelectors}
                >
                    <Dropdown
                        value={playerNames[0]}
                        selectedOptions={[playerNames[0]]}
                        onOptionSelect={(_, data) => handlePlayerNameChange(0, data.optionValue as string)}
                        disabled={!avalibleSettings.engines || avalibleSettings.engines.length === 0}
                    >
                        {avalibleSettings.engines && avalibleSettings.engines.map((option) => (
                            <Option
                                key={option}
                                text={option}
                                value={option}
                                disabled={avalibleSettings?.disabledEngines?.includes(option)}
                            >
                                {option}
                            </Option>
                        ))}
                    </Dropdown>
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