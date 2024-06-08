import {
    Button,
    ToastTitle,
    Toast,
    Link,
    ToastTrigger,
    Spinner,
} from "@fluentui/react-components";
import { Dismiss16Regular } from "@fluentui/react-icons";

export const ProgressToast = (props: {
    message: string;
}) => {
    const {
        message
    } = props;

    return (
        <Toast>
            <ToastTitle
                media={<Spinner size="tiny" />}
                action={
                    <ToastTrigger>
                        <Link>
                            <Button
                                appearance="subtle"
                                icon={<Dismiss16Regular />}
                            />
                        </Link>
                    </ToastTrigger>
                }
            >
                {message}
            </ToastTitle>
        </Toast>
    );
}