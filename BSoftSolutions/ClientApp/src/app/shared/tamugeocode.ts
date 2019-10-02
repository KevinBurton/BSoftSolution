import { tamuaddress } from "./tamuaddress";
import { tamuoutputgeocode } from "./tamuoutputgeocode";

export class tamugeocode {
    public version: string;
    public TransactionId: string;
    public Version: string;
    public QueryStatusCodeValue: string;
    public FeatureMatchingResultValue: string;
    public FeatureMatchingResultCount: number;
    public TimeTaken: string;
    public ExceptionOccured: boolean;
    public Exception: object;
    public InputAddress: tamuaddress;
    public OutputGeocodes: tamuoutputgeocode[];
}