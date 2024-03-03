import { useId, useToastController } from "@fluentui/react-components";
import { useWebApi } from "../../context";
import { DefaultToast, ProgressToast } from "../../components";

export const UseSettings = (
    toastControllerId: string,
): {
    saveSettings: () => void;
} => {
    // Hooks
    const webApi = useWebApi();
    const {
        dispatchToast,
        updateToast,
        dismissToast
    } = useToastController(toastControllerId);
    const savingSettingsToastId = useId("savingSettings");
    
    // State

    // Functions
    const saveSettings = async () => {
        dispatchToast(
            <ProgressToast
                message="Something went wrong while calling the API"
            />,
            {
                toastId: savingSettingsToastId,
                timeout: -1,
            }
        );
        try {
            //const response = await webApi.makeMovePlayer(playerId, square);
            await new Promise(f => setTimeout(f, 1000));
            updateToast({
                content: (
                    <DefaultToast
                        message="Something went wrong while calling the API"
                    />
                ),
                intent: "success",
                toastId: savingSettingsToastId,
                timeout: 2000,
              });
        }
        catch (error) {
            dispatchToast(
                <DefaultToast
                    message="Something went wrong while calling the API"
                />,
                {
                    intent: "error",
                    toastId: savingSettingsToastId,
                    timeout: 2000,
                }
            );
        }
    }

    return {
        saveSettings,
    }
}