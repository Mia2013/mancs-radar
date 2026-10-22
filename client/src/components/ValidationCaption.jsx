import { Typography } from '@mui/material'

const ValidationCaption = ({ message }) => {
    return (
<Typography variant='caption' sx={{ color: "error.main", ml: 2, mt: 0.5 }}>{message}</Typography>
    )}

export default ValidationCaption