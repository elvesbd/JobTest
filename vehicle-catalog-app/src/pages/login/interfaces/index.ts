export interface LoginProps {
  email: string;
  password: string;
}

export interface LoginResponseProps {
  data: string;
}

export type EventProps = React.ChangeEvent<HTMLInputElement>
export type FormEventProps =  React.FormEvent<HTMLFormElement>