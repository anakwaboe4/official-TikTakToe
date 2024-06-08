import { useId, useToastController } from "@fluentui/react-components";
import { useWebApi } from "../../context";
import { DefaultToast, ProgressToast } from "../../components";
import { useEffect, useState } from "react";

export const UseSettings = (
    toastControllerId: string,
): {
    saveSettings: () => void;
} => {
    // Hooks
    const webApi = useWebApi();
    const {
        dispatchToast,
        updateToast
    } = useToastController(toastControllerId);
    const savingSettingsToastId = useId("savingSettings", toastControllerId);
    
    // State
    const [avalibleEngines, setAvalibleEngines] = useState<string[]>([]);

    // Functions
    const saveSettings = async () => {
        const randomNumber = Math.floor(Math.random() * 100);
        dispatchToast(
            <ProgressToast
                message="Saving settings..."
            />,
            {
                toastId: savingSettingsToastId + randomNumber,
                timeout: -1,
            }
        );
        try {
            //const response = await webApi.makeMovePlayer(playerId, square);
            await new Promise(f => setTimeout(f, 1000));
            updateToast({
                content: (
                    <DefaultToast
                        message="Settings saved!"
                    />
                ),
                intent: "success",
                toastId: savingSettingsToastId + randomNumber,
                timeout: 2000,
              });
        }
        catch (error) {
            dispatchToast(
                <DefaultToast
                    message="Something went wrong while saving the settings"
                />,
                {
                    intent: "error",
                    toastId: savingSettingsToastId + randomNumber,
                    timeout: 2000,
                }
            );
        }
    }

    // Effects
    useEffect(() => {
        const fetchAvalibleEngines = async () => {
            try {
                const response = await webApi.getAvailableEngines();
                setAvalibleEngines(response);
            } catch (error) {
                dispatchToast(
                    <DefaultToast
                        message="Something went wrong while calling the API"
                    />,
                    {
                        intent: "error",
                    }
                )
            }
        };

        fetchAvalibleEngines();
    }, []);

    return {
        saveSettings,
    }
}