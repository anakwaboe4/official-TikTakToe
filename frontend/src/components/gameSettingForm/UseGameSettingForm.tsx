import { useState, useEffect } from "react";
import { useCookies } from '../../hooks';
import { ISettingsResponse } from "../../models";

export const UseGameSettingForm = (
    avalibleSettings: ISettingsResponse,
): {
    playerCount: number;
    onPlayerCountChange: (playerCount?: number | null | undefined) => void;
    lengthX: number;
    onLengthXChange: (lengthX?: number | null | undefined) => void;
    lengthY: number;
    onLengthYChange: (lengthY?: number | null | undefined) => void;
    playerNames: string[];
    handlePlayerNameChange: (index: number, newName: string) => void;
} => {
    // Hooks
    const { setCookie, getCookie } = useCookies();
    
    // State
    const [playerCount, setPlayerCount] = useState<number>(2);
    const [LengthX, setLengthX] = useState<number>(3);
    const [LengthY, setLengthY] = useState<number>(3);
    const [playerNames, setPlayerNames] = useState<string[]>(Array(2).fill(avalibleSettings?.engines ? avalibleSettings?.engines?.[0] : ""));

    // Functions
    const onPlayerCountChange = (playerCount?: number | null | undefined) => {
        if (playerCount !== null && playerCount !== undefined) {
            setPlayerCount(playerCount);
            saveSettings();
        }
    }
    const onLengthXChange = (lengthX?: number | null | undefined) => {
        if (lengthX !== null && lengthX !== undefined) {
            setLengthX(lengthX);
            saveSettings();
        }
    }
    const onLengthYChange = (lengthY?: number | null | undefined) => {
        if (lengthY !== null && lengthY !== undefined) {
            setLengthY(lengthY);
            saveSettings();
        }
    }
    
    const handlePlayerNameChange = (index: number, newName: string) => {
        if (avalibleSettings.engines && (avalibleSettings.engines.includes(newName))) {
            let newPlayerNames = [...playerNames];
            newPlayerNames[index] = newName;
            setPlayerNames(newPlayerNames);
            saveSettings();
        }
    };

    const saveSettings = () => {
        let settings = {
            playerCount: playerCount,
            lengthX: LengthX,
            lengthY: LengthY,
            players: [
                ...playerNames
            ]
        }

        let settingsJson = JSON.stringify(settings);

        setCookie("TicTacToe.Settings", settingsJson);
    }
    const loadSettings = () => {
        let settingsJson = getCookie("TicTacToe.Settings");

        if (settingsJson) {
            let settings = JSON.parse(settingsJson);

            setPlayerCount(settings.playerCount);
            setLengthX(settings.lengthX);
            setLengthY(settings.lengthY);
            let testplayers = settings.players;
            setPlayerNames(settings.players);
        }
    }

    // Effects
    useEffect(() => {
        if(avalibleSettings?.engines && avalibleSettings?.engines.length > 0) {
            setPlayerNames(Array(playerCount).fill(avalibleSettings?.engines[0]));
        }
    }, [avalibleSettings]);

    useEffect(() => {
        loadSettings();
    }, []);

    return {
        playerCount,
        onPlayerCountChange,
        lengthX: LengthX,
        onLengthXChange,
        lengthY: LengthY,
        onLengthYChange,
        playerNames,
        handlePlayerNameChange,
    }
}