export interface UserProps {
  name: string;
  email: string;
  cellPhone: string;
  password: string;
}

export type EventProps = React.ChangeEvent<HTMLInputElement>
export type FormEventProps =  React.FormEvent<HTMLFormElement>