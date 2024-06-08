import { useState } from "react";

export const UseGameSettingForm = (
    
): {
    playerCount: number;
    onPlayerCountChange: (playerCount?: number | null | undefined) => void;
    lengthX: number;
    onLengthXChange: (lengthX?: number | null | undefined) => void;
    lengthY: number;
    onLengthYChange: (lengthY?: number | null | undefined) => void;
} => {
    // Hooks
    
    // State
    const [playerCount, setPlayerCount] = useState<number>(2);
    const [LengthX, setLengthX] = useState<number>(3);
    const [LengthY, setLengthY] = useState<number>(3);

    // Functions
    const onPlayerCountChange = (playerCount?: number | null | undefined) => {
        if (playerCount !== null && playerCount !== undefined) {
            setPlayerCount(playerCount);
        }
    }
    const onLengthXChange = (lengthX?: number | null | undefined) => {
        if (lengthX !== null && lengthX !== undefined) {
            setLengthX(lengthX);
        }
    }
    const onLengthYChange = (lengthY?: number | null | undefined) => {
        if (lengthY !== null && lengthY !== undefined) {
            setLengthY(lengthY);
        }
    }

    return {
        playerCount,
        onPlayerCountChange,
        lengthX: LengthX,
        onLengthXChange,
        lengthY: LengthY,
        onLengthYChange,
    }
}